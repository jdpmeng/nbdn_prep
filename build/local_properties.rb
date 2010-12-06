class LocalSettings 
  attr_reader :settings
  def initialize
    @settings = {:use_vs2010 => true}
  end
end
