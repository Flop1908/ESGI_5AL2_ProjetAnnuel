


#import "AnnePageControl.h"

@interface AnnePageControl()
@property (nonatomic, weak) UIPageControl *topPageControl;//Top
@property (nonatomic, weak) UIPageControl *flopPageControl;//Flop
@property (nonatomic, weak) UIPageControl *randomPageControl;
@property (nonatomic, weak) UIPageControl *fluxPageControl;
@property (nonatomic, weak) UIPageControl *chronologyPageControl;
@property NSInteger currentMaskPage;
@property CGFloat lastMaskedPercentage;

@end

@implementation AnnePageControl

- (id)initWithFrame:(CGRect)frame {
    self = [super initWithFrame:frame];
    if (!self) {
        return nil;
    }
	
    [self setupPageControls];
	return self;
}

- (id)init {
	self = [super init];
	if (!self) {
		return nil;
	}
	
	[self setupPageControls];
	return self;
}

- (void)awakeFromNib {
	[super awakeFromNib];
	[self setupPageControls];
}

- (void)setupPageControls {
	if (!self.topPageControl) {
		UIPageControl *topPageControl = [[UIPageControl alloc] init];
        [topPageControl setUserInteractionEnabled:NO];
		[self addSubview:topPageControl];
		self.topPageControl = topPageControl;
		
		UIPageControl *flopPageControl = [[UIPageControl alloc] init];
        [flopPageControl setUserInteractionEnabled:NO];
		[self addSubview:flopPageControl];
		self.flopPageControl = flopPageControl;
        
        UIPageControl *randomPageControl = [[UIPageControl alloc] init];
        [randomPageControl setUserInteractionEnabled:NO];
		[self addSubview:randomPageControl];
		self.randomPageControl = randomPageControl;

        UIPageControl *fluxPageControl = [[UIPageControl alloc] init];
        [fluxPageControl setUserInteractionEnabled:NO];
		[self addSubview:fluxPageControl];
		self.fluxPageControl = fluxPageControl;

        UIPageControl *chronologyPageControl = [[UIPageControl alloc] init];
        [chronologyPageControl setUserInteractionEnabled:NO];
		[self addSubview:chronologyPageControl];
		self.chronologyPageControl = chronologyPageControl;
		
		[self syncPageControl];
        self.currentMaskPage = 0;
        [self refreshCurrentPageColors];
        self.lastMaskedPercentage = 0.0;
	}
}

- (void)syncPageControl {
	self.flopPageControl.currentPage = self.topPageControl.currentPage = self.currentPage;
	self.flopPageControl.numberOfPages = self.topPageControl.numberOfPages = self.numberOfPages;
	self.flopPageControl.defersCurrentPageDisplay = self.topPageControl.defersCurrentPageDisplay = self.defersCurrentPageDisplay;
	self.flopPageControl.hidesForSinglePage = self.topPageControl.hidesForSinglePage = self.hidesForSinglePage;
	
    self.flopPageControl.opaque = self.topPageControl.opaque = self.opaque;
	self.flopPageControl.backgroundColor = self.topPageControl.backgroundColor = self.backgroundColor;
}

- (void)layoutSubviews {
	[super layoutSubviews];
	self.topPageControl.frame = self.bounds;
	self.flopPageControl.frame = self.bounds;
    self.randomPageControl.frame = self.bounds;
    self.fluxPageControl.frame = self.bounds;
    self.chronologyPageControl.frame = self.bounds;
    
    [self updateMaskWithPercentage:self.lastMaskedPercentage];
}

#pragma mark - Synthesis Overriding

- (void)setCurrentPage:(NSInteger)currentPage {
	_currentPage = currentPage;
	
	[self syncPageControl];
}

- (void)setNumberOfPages:(NSInteger)numberOfPages {
	_numberOfPages = MAX(0, numberOfPages);
	self.currentPage = MIN(MAX(0, self.currentPage), numberOfPages);
    
	[self syncPageControl];
	
	self.bounds = (CGRect){.size = [self sizeForNumberOfPages:numberOfPages]};
	self.hidden = self.hidesForSinglePage && self.numberOfPages < 2;
}

- (void)setDefersCurrentPageDisplay:(BOOL)defersCurrentPageDisplay {
	_defersCurrentPageDisplay = defersCurrentPageDisplay;
	
	[self syncPageControl];
}

- (void)setHidesForSinglePage:(BOOL)hidesForSinglePage {
	_hidesForSinglePage = hidesForSinglePage;
	
	[self syncPageControl];
}

- (void)setDataSource:(id<AnnePageControlDataSource>)dataSource {
    _dataSource = dataSource;
    [self refreshCurrentPageColors];
}

#pragma mark - UIPageControl Methods

- (void)updateCurrentPageDisplay {
	[self.topPageControl updateCurrentPageDisplay];
	[self.flopPageControl updateCurrentPageDisplay];
	[self.randomPageControl updateCurrentPageDisplay];
	[self.fluxPageControl updateCurrentPageDisplay];
	[self.chronologyPageControl updateCurrentPageDisplay];
}

- (CGSize)sizeForNumberOfPages:(NSInteger)pageCount {
	return [self.topPageControl sizeForNumberOfPages:pageCount];
}

#pragma mark - Masking
//Page's Background
- (void)refreshCurrentPageColors {
    if (!self.dataSource) {
        return;
    }
    
    UIColor *topCurrentIndicatorTint = [self.dataSource pageControl:self currentPageIndicatorTintColorForIndex:self.currentMaskPage];
    UIColor *topIndicatorTint = [self.dataSource pageControl:self pageIndicatorTintColorForIndex:self.currentMaskPage];
    UIColor *flopCurrentIndicatorTint = [self.dataSource pageControl:self currentPageIndicatorTintColorForIndex:self.currentMaskPage+1];
    UIColor *flopIndicatorTint = [self.dataSource pageControl:self pageIndicatorTintColorForIndex:self.currentMaskPage+1];
    UIColor *randomCurrentIndicatorTint = [self.dataSource pageControl:self currentPageIndicatorTintColorForIndex:self.currentMaskPage+1];
    UIColor *randomIndicatorTint = [self.dataSource pageControl:self pageIndicatorTintColorForIndex:self.currentMaskPage+1];
    UIColor *fluxCurrentIndicatorTint = [self.dataSource pageControl:self currentPageIndicatorTintColorForIndex:self.currentMaskPage+1];
    UIColor *fluxIndicatorTint = [self.dataSource pageControl:self pageIndicatorTintColorForIndex:self.currentMaskPage+1];
    UIColor *chronologyCurrentIndicatorTint = [self.dataSource pageControl:self currentPageIndicatorTintColorForIndex:self.currentMaskPage+1];
    UIColor *chronologyIndicatorTint = [self.dataSource pageControl:self pageIndicatorTintColorForIndex:self.currentMaskPage+1];
    
    [self.topPageControl setCurrentPageIndicatorTintColor:topCurrentIndicatorTint];
    [self.topPageControl setPageIndicatorTintColor:topIndicatorTint];
    [self.flopPageControl setCurrentPageIndicatorTintColor:flopCurrentIndicatorTint];
    [self.flopPageControl setPageIndicatorTintColor:flopIndicatorTint];
    [self.randomPageControl setCurrentPageIndicatorTintColor:randomCurrentIndicatorTint];
    [self.randomPageControl setPageIndicatorTintColor:randomIndicatorTint];
    [self.fluxPageControl setCurrentPageIndicatorTintColor:fluxCurrentIndicatorTint];
    [self.fluxPageControl setPageIndicatorTintColor:fluxIndicatorTint];
    [self.chronologyPageControl setCurrentPageIndicatorTintColor:chronologyCurrentIndicatorTint];
    [self.chronologyPageControl setPageIndicatorTintColor:chronologyIndicatorTint];
}

- (void)maskEventWithOffset:(CGFloat)offset frame:(CGRect)frame {
    int page = floorf(offset / CGRectGetWidth(frame));
    
    CGFloat offsetRemainder = offset - page * CGRectGetWidth(frame);
    CGFloat percentage = MIN(CGRectGetWidth(frame), MAX(0, offsetRemainder - CGRectGetMinX(self.frame))) / CGRectGetWidth(self.bounds);
    
    if (self.currentMaskPage != page) {
        self.currentMaskPage = page;
        [self refreshCurrentPageColors];
    }
    
    [self updateMaskWithPercentage:percentage];
}


- (void)updateMaskWithPercentage:(CGFloat)percentage {
    percentage = MIN(MAX(0, percentage), 1);
    
	if (!self.layer.mask) {
		self.topPageControl.layer.mask = [CALayer layer];
		self.topPageControl.layer.mask.backgroundColor = [[UIColor blackColor] CGColor];
		
		self.flopPageControl.layer.mask = [CALayer layer];
		self.flopPageControl.layer.mask.backgroundColor = [[UIColor blackColor] CGColor];
        
        self.randomPageControl.layer.mask = [CALayer layer];
		self.randomPageControl.layer.mask.backgroundColor = [[UIColor blackColor] CGColor];
        
        self.fluxPageControl.layer.mask = [CALayer layer];
		self.fluxPageControl.layer.mask.backgroundColor = [[UIColor blackColor] CGColor];
        
        self.chronologyPageControl.layer.mask = [CALayer layer];
		self.chronologyPageControl.layer.mask.backgroundColor = [[UIColor blackColor] CGColor];
	}
	
	[CATransaction begin];
	[CATransaction setDisableActions:YES]; // Removed implicit animation that was causing delays
	CGRect chronologyMaskFrame = self.chronologyPageControl.layer.bounds;
	chronologyMaskFrame.origin.x = CGRectGetWidth(chronologyMaskFrame) * (1 - percentage);
	chronologyMaskFrame.size.width = CGRectGetWidth(chronologyMaskFrame) * percentage;
	self.chronologyPageControl.layer.mask.frame = chronologyMaskFrame;
	
    CGRect fluxMaskFrame = self.fluxPageControl.layer.bounds;
	fluxMaskFrame.origin.x = CGRectGetWidth(fluxMaskFrame) * (1 - percentage);
	fluxMaskFrame.size.width = CGRectGetWidth(fluxMaskFrame) * percentage;
	self.fluxPageControl.layer.mask.frame = fluxMaskFrame;
    
    CGRect randomMaskFrame = self.randomPageControl.layer.bounds;
	randomMaskFrame.origin.x = CGRectGetWidth(randomMaskFrame) * (1 - percentage);
	randomMaskFrame.size.width = CGRectGetWidth(randomMaskFrame) * percentage;
	self.randomPageControl.layer.mask.frame = randomMaskFrame;
    
    CGRect flopMaskFrame = self.flopPageControl.layer.bounds;
	flopMaskFrame.origin.x = CGRectGetWidth(flopMaskFrame) * (1 - percentage);
	flopMaskFrame.size.width = CGRectGetWidth(flopMaskFrame) * percentage;
	self.flopPageControl.layer.mask.frame = flopMaskFrame;
    
	CGRect pageControlFrame = self.topPageControl.layer.bounds;
    pageControlFrame.origin.x = 0;
	pageControlFrame.size.width = CGRectGetWidth(pageControlFrame) * (1 - percentage);
	self.topPageControl.layer.mask.frame = pageControlFrame;
	[CATransaction commit];
    
    self.lastMaskedPercentage = percentage;
}

#pragma mark - UIControl Method

- (void)touchesEnded:(NSSet *)touches withEvent:(UIEvent *)event {
	UITouch *tap = [touches anyObject];
	CGPoint location = [tap locationInView:self];
	
	if (location.x < CGRectGetMidX(self.bounds)) {
		self.currentPage = MAX(0, self.currentPage - 1);
	} else {
		self.currentPage = MIN(self.currentPage + 1, self.numberOfPages - 1);
	}
	
	[self sendActionsForControlEvents:UIControlEventValueChanged];
}
@end
